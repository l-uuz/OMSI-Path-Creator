namespace Omsipath
{

    [Serializable]
    internal class PreconditionException : Exception
    {
        public PreconditionException(string message) : base(message) { }
    }
}
