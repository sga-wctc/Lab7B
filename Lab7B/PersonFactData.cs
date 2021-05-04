using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7B
{
    class PersonFactData
    {
        public static IEnumerable<PersonFactData> All { private set; get; }
        public string TheFact { get; set; }
        public string ShortFact { get; set; }
        public string ImageFile { get; set; }
        static PersonFactData()
        {
            List<PersonFactData> all = new List<PersonFactData>();
            all.Add(new PersonFactData()
            {
                TheFact = "I will eat bananas on occassion",
                ShortFact = "Banana?",
                ImageFile = "Banana.jpg"
            });
            all.Add(new PersonFactData()
            {
                TheFact = "I prefer Green Beans",
                ShortFact = "Lagumes/Beans?",
                ImageFile = "Legumes.jpg"
            });
            all.Add(new PersonFactData()
            {
                TheFact = "I prefer marina sauce with spagetti",
                ShortFact = "Tomatos?",
                ImageFile = "tomato.png"
            });
            all.Add(new PersonFactData()
            {
                TheFact = "I enjoy most vegetables",
                ShortFact = "Vegatables?",
                ImageFile = "Vegetables.jpg"
            });
            all.Add(new PersonFactData()
            {
                TheFact = "Is zucchini really a vegetable?",
                ShortFact = "Zucchini?",
                ImageFile = "zucchini.png"
            });
            All = all;

        }
    }

}
