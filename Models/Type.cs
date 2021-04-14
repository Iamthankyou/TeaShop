using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WecareMVC.Models
{
    public class Type
    {
        [Key]
        [DisplayName("Mã loại trà")]
        public int TypeId { get; set; }
        [DisplayName("Loại trà sữa")]
        public string Name { get; set; }
        [DisplayName("Thông tin trà:")]
        public string Description { get; set; }
        [DisplayName("Danh sách trà: ")]
        public List<Tea> Teas { get; set; }
        //public virtual List<Tea> Teas { get; set; }
    



        public IEnumerable<Tea> GetTopTea(int count)
        {
            TeaEntities db = new TeaEntities();
            var Teas = db.Teas.Where(a => a.TypeId == TypeId).
                OrderByDescending(a => a.OrderDetails
                .Sum(o=>o.Quantity))
                .Take(count)
                .ToList();
            return Teas;
        }
    }

    //should add using WecareMVC.Models in Razor view
    public static class TypeExtension
    {
        public static IEnumerable<Tea> GetTopTea(this  WecareMVC.Models.Type Type, int count)
        {
            TeaEntities db = new TeaEntities();
            var Teas = db.Teas.Where(a=>a.TypeId==Type.TypeId).
                OrderByDescending(a => a.OrderDetails.Sum(o => o.Quantity))
                .Take(count)
                .ToList();
            return Teas;
        }
    }  
}
       // private Tea[] _Tea;

//        public Type() : this(new Tea[5])

//        public Type(Tea[] pArray)
//    {
//        _Tea = new Tea[pArray.Length];

//        for (int i = 0; i < pArray.Length; i++)
//        {
//            _Tea[i] = pArray[i];
//        }
//    }

//        IEnumerator IEnumerable.GetEnumerator()
//        {
//            return (IEnumerator)GetEnumerator();
//        }

//        public PeopleEnum GetEnumerator()
//        {
//            return new PeopleEnum(_Tea);
//        }
//    }

//    public class PeopleEnum : IEnumerator
//    {
//        public Tea[] _people;

//        // Enumerators are positioned before the first element
//        // until the first MoveNext() call.
//        int position = -1;

//        public PeopleEnum(Tea[] list)
//        {
//            _people = list;
//        }

//        public bool MoveNext()
//        {
//            position++;
//            return (position < _people.Length);
//        }

//        public void Reset()
//        {
//            position = -1;
//        }

//        object IEnumerator.Current
//        {
//            get
//            {
//                return Current;
//            }
//        }

//        public Tea Current
//        {
//            get
//            {
//                try
//                {
//                    return _people[position];
//                }
//                catch (IndexOutOfRangeException)
//                {
//                    throw new InvalidOperationException();
//                }
//            }
//        }
//    }
//}