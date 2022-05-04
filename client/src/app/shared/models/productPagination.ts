import { IProduct } from './product';

export interface IProductPagination {
  pageIndex: number;
  pageSize: number;
  count: number;
  data: IProduct[];
}
