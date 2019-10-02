using Fluent.Architecture.Exceptions.ValidationException;

namespace MVCWebSite.product_scope
{
    public class SaleAlreadyCompletedException : FluentValidationException
    {
        public SaleAlreadyCompletedException(string message) : base(message) { }
    }
}
