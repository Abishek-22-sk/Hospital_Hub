namespace HealthHub.Models.ReturnModel
{
    public class ReturnModel<T>
    {
        public string Message { get; set; }

        public T Value { get; set; }
    }
}
