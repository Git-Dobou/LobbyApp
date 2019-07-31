import { IMember } from './IMember';
import { IAddress } from './IAddress';
import { IPenalty } from './IPenalty';

export interface ISession {
  id?: string;
  date?: Date;
  panaltys?: IPenalty[];
  member?: IMember;
  address?: IAddress;
  report?: string;
}
