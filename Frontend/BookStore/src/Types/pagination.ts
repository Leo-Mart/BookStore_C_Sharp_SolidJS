export interface PaginationMetaData {
  TotalItemCount: number;
  TotalPageCount: number;
  PageSize: number;
  CurrentPage: number;
}

export interface FetchParams {
  pageNumber: number;
  pageSize: number;
}
