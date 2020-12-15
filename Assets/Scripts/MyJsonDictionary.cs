using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class MyJsonDictionary<K, V> : ISerializable {
       public Dictionary<K, V> dict = new Dictionary<K, V>();

        public MyJsonDictionary() { }

        protected MyJsonDictionary( SerializationInfo info, StreamingContext context ) {
            
        }

        public void GetObjectData( SerializationInfo info, StreamingContext context ) {
            foreach( K key in dict.Keys ) {
                info.AddValue( key.ToString(), dict[ key ] );
            }
        }

        public void Add( K key, V value ) {
            dict.Add( key, value );
        }
        public V GetVal( K key )
        {
            Debug.Log(dict.Count);
            return dict[key];
        }
        public V this[ K index ] {
            set { dict[ index ] = value; }
            get { return dict[ index ]; }
        }
    }
}