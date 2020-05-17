import { InputType, Field } from "type-graphql";
import { Length } from "class-validator";
import { Task } from "../../entities/task";
import { ObjectId } from "mongodb";

@InputType()
export class TaskInput implements Partial<Task> {
	@Field()
	@Length(1, 250)
	title: string;

	@Field()
	description: string;

	@Field()
	completed: boolean;

	@Field()
	order: number;

	@Field(() => String)
	section_id: ObjectId;
}
