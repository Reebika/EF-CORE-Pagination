using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1
{
    public class TodosResponse<T>
    {
        public List<T> Todos{ get; private set; }
        public int TotalCount { get; private set; }
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

        public TodosResponse(List<T> todos, int totalCount, int pageNumber, int pageSize)
        {
            Todos = todos;
            TotalCount = totalCount;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
