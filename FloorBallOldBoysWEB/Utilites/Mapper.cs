using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FloorBallOldBoysWEB.Utilites
{
    internal static class Mapper
    {
        public static ModelToViewModelMapper ModelToViewModelMapping { get; }
        public static ViewModelToModelMapper ViewModelToModelMapping { get; }

        static Mapper()
        {
            ModelToViewModelMapping = new ModelToViewModelMapper();
            ViewModelToModelMapping = new ViewModelToModelMapper();
        }

    }
}
