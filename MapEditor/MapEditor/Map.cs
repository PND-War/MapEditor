using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MapEditor
{
    [DataContract]
    public class Map
    {
        [DataMember]
        public int Wood;
        [DataMember]
        public int Gold;
        [DataMember]
        public Field[,] map { get; set; }
        [DataMember]
        public List<AUnit> units;
        public Map(Field[,] mapTo)
        {
            map = mapTo;
            Wood = 500;
            Gold = 500;
        }
    }
}
