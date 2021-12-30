using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
  public   interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key);//generic olayan versiyonu 
        void Add(string key, object data, int duration);
        bool IsAdd(string key);
        //cacheden mi yoksa veri tabanindan mi cache de varsa cacheden yoksa verutabanindan ekleyip cache e ekleriz 

        void Remove(string key);//cachedeb ucurma
        void RemoveByPattern(string pattern);//hepsini degil sectigimizi ucurma 
        //regixpattern 
    }
}
