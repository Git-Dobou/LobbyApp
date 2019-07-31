import { IAddress } from './IAddress';

export interface IMember {
  userName?: string;
  password?: string;
  repeatPassword?: string;
  firstName?: string;
  lastName?: string;
  image?: string;
  birdDay?: Date;
  address?: IAddress;
  date_Session?: Date;
  to_Pay?: number;
  to_Pay_Open?: number;
}
