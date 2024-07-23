namespace CQRSlite.Extensions.Utilities
{
    public static class Guid
    {
        //Guid is generated according to the naming convention of WPF controls,
        //which means that starts with non-digit character.
        public static System.Guid NewGuid()
        {
            var guid = System.Guid.NewGuid();
            string name = guid.ToString();

            while (char.IsDigit(name[0]))
            {
                guid = System.Guid.NewGuid();
                name = guid.ToString();
            }

            return guid;
        }
    }
}
