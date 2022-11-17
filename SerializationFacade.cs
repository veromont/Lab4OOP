namespace JSON_manager
{
    internal class SerializationClass
    {
        public static bool DeserializeFromFile()
        {
            DeserializerClass Reader = new DeserializerClass();
            return Reader.Deserialize(); ;
        }
        public static bool SerializeWith(Conferention ChangedObj)
        {
            SerializerClass Serializer = new SerializerClass(ChangedObj);
            return Serializer.Serialize();
        }
        public static bool SerializeWithout(Conferention DeletedObject)
        {
            SerializerClass Serializer = new SerializerClass(DeletedObject);
            return Serializer.SerializeWithout();
        }
    }
}
