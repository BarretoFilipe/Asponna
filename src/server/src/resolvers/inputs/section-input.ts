import { InputType, Field } from "type-graphql";
import { Length } from "class-validator";
import { Section } from "../../entities/section";

@InputType()
export class SectionInput implements Partial<Section> {
	@Field()
	@Length(1, 250)
	name: string;

	@Field()
	order: number;
}
