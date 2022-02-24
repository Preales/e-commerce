namespace Ecommerce.Common.Dtos
{
    public class DeletedInfo<T>
    {
        public T Id { get; set; }
        public string UserName { get; set; }

        public DeletedInfo() {}

        public DeletedInfo(T id, string userName)
        {
            Id = id;
            UserName = userName;
        }
    }
}