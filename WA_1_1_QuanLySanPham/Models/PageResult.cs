namespace WA_1_1_QuanLySanPham.Models
{
    public class PageResult<T>
    {
        public Pagination Pagination { get; set; }
        public List<T> Data { get; set; }
        public PageResult(Pagination pagination, List<T> data)
        {
            Pagination = pagination;
            Data = data;
        }
        public static List<T> ToPageResult(Pagination pagination, List<T> data)
        {
            pagination.PageNumber = pagination.PageNumber < 1 ? 1 : pagination.PageNumber;
            data = data.Skip(pagination.PageSize * (pagination.PageNumber - 1)).Take(pagination.PageSize).ToList();
            return data;
        }
    }
}
