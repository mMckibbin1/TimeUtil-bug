using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace TimeUtil.BussinesLogic
{
    internal class CategoiresConverter : ITypeConverter
    {
        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {

            if (text == string.Empty)
            {
                HashSet<string> set = new(1);

                set.Add("Uncategorised");

                return set;
            }
            
            return text.Split(';').ToHashSet();
        }

        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            throw new NotImplementedException();
        }
    }
}
