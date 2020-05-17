import { ObjectType, Field, ID, Int } from "type-graphql";
import { prop as Property, getModelForClass } from "@typegoose/typegoose";
import { Ref } from "../types";
import { Section } from "./section";

@ObjectType({ description: "Task Model" })
export class Task {
	@Field(() => ID)
	id: string;

	@Field()
	@Property({
		required: true,
		trim: true,
		validate: {
			validator: (value) => value.length > 0,
			message: `title has a min length 0`,
		},
	})
	title: string;

	@Field()
	@Property({
		trim: true,
	})
	description: string;

	@Field()
	@Property({
		default: new Date(),
	})
	create_date: Date;

	@Field()
	@Property()
	completed: boolean;

	@Field((__type) => Int)
	@Property({
		min: 1,
	})
	order: number;

	@Field((__type) => String)
	@Property({
		ref: Section,
	})
	section_id: Ref<Section>;
	__doc: any;
}

export const TaskModel = getModelForClass(Task);
