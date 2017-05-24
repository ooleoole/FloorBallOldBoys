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
