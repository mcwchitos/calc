namespace calc
{
    public enum Operations
    {
        Multiplication, Division, Subtraction, Addition, None
    }

    internal static class OperationsMethods
    {
        public static string GetOp(this Operations operation)
        {
            return operation switch
            {
                Operations.Multiplication => "*",
                Operations.Division => "/",
                Operations.Addition => "+",
                Operations.Subtraction => "-",
                _ => "none"
            };
        }
    }
}