import { Resolver, Query, Mutation, Arg } from "type-graphql";
import { Task, TaskModel } from "../entities/task";
import { TaskInput } from "./inputs/task-input";
import { SectionModel } from "../entities/section";

@Resolver()
export class TaskResolver {
	@Query((_returns) => Task, { nullable: false })
	async getTask(@Arg("id") id: string) {
		return await TaskModel.findById({ _id: id });
	}

	@Query(() => [Task])
	async getAllTask() {
		return await TaskModel.find();
	}

	@Mutation(() => Task)
	async createTask(@Arg("data") { title, description, completed, order, section_id }: TaskInput): Promise<Task> {
		const section = await SectionModel.findById(section_id);
		if (section === null) {
			throw new Error(`section doesn't exists`);
		}

		const task = (
			await TaskModel.create({
				title,
				description,
				completed,
				order,
				section_id,
			})
		).save();
		return task;
	}

	@Mutation(() => Boolean)
	async deleteTask(@Arg("id") id: string) {
		await TaskModel.findByIdAndDelete(id);
		return true;
	}
}
