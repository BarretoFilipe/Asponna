import { ObjectType, Field, ID, Int } from "type-graphql";
import { prop as Property, getModelForClass } from "@typegoose/typegoose";

@ObjectType({ description: "Tasks section model" })
export class Section {
	@Field(() => ID)
	id: string;

	@Field()
	@Property({
		required: true,
		trim: true,
		validate: {
			validator: (value) => value.length > 0,
			message: `name has a min length 0`,
		},
	})
	name: string;

	@Field((__type) => Int)
	@Property({
		min: 1,
	})
	order: number;
}

export const SectionModel = getModelForClass(Section);
