

namespace UrTask.Data.DRY
{
    public class CustomMapping
    {
        public static dynamic MappingDynamic<T>(T item)
        {
            return item;
        }

        public static object Mapping<T>(T item)
        {
            return item;
        }
    }
}
