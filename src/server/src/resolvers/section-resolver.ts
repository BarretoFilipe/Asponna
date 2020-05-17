import { Resolver, Query, Mutation, Arg } from "type-graphql";
import { Section, SectionModel } from "../entities/section";
import { SectionInput } from "./inputs/section-input";

@Resolver()
export class SectionResolver {
	@Query((_returns) => Section, { nullable: false })
	async getSection(@Arg("id") id: string) {
		return await SectionModel.findById({ _id: id });
	}

	@Query(() => [Section])
	async getAllSection() {
		return await SectionModel.find();
	}

	@Mutation(() => Section)
	async createSection(@Arg("data") { name, order }: SectionInput): Promise<Section> {
		const section = (
			await SectionModel.create({
				name,
				order,
			})
		).save();
		return section;
	}

	@Mutation(() => Boolean)
	async deleteSection(@Arg("id") id: string) {
		await SectionModel.findByIdAndDelete(id);
		return true;
	}

	/*@Mutation(() => Section)
	async updateSection(@Arg("data") { id, name, order }: SectionInput): Promise<Section> {
		const section = await SectionModel.findByIdAndUpdate(
			id,
			{
				name,
				order,
			},
			(err: any, todo: any) => {
				// Handle any possible database errors
				if (err) {
					return err;
				}
				return todo;
			}
		);
		return section;
	}*/
}
