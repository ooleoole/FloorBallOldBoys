namespace FloorBallOldBoysWEB.Utilites
{
    internal static class Mapper
    {
        static Mapper()
        {
            ModelToViewModelMapping = new ModelToViewModelMapper();
            ViewModelToModelMapping = new ViewModelToModelMapper();
        }

        public static ModelToViewModelMapper ModelToViewModelMapping { get; }
        public static ViewModelToModelMapper ViewModelToModelMapping { get; }
    }
}