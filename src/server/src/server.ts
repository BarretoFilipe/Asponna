import { ApolloServer } from "apollo-server";
import "reflect-metadata";
import { buildSchema } from "type-graphql";
import { connect } from "mongoose";
import { mongoConnectionString, port } from "./constants/api-constants";

import { SectionResolver } from "./resolvers/section-resolver";
import { TaskResolver } from "./resolvers/task-resolver";

const main = async () => {
	const schema = await buildSchema({
		resolvers: [SectionResolver, TaskResolver],
		emitSchemaFile: true,
		validate: false,
	});

	const mongoose = await connect(mongoConnectionString, { useNewUrlParser: true, useUnifiedTopology: true });
	await mongoose.connection;

	const server = new ApolloServer({ schema });
	server.listen(port);
};

main().catch((error) => {
	console.log(error, "error");
});
