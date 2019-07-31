using System.Collections.Generic;
using System.Linq;
using App.Models;

namespace App.Services
{
    public class TranslatorService
    {
        private List<TranslatorObject> cachedTranslatorObjects;

        public TranslatorObject this[string index]
        {
            get
            {
                var result = cachedTranslatorObjects.FirstOrDefault(ob => ob.Name == index);

                if (result == null)
                    return TranslatorObject.NullObject;

                return result;
            }
        }

        private void LoadFromDb()
        {
            
        }
    }
}