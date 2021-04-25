using LightInject;

namespace DOS_DAL
{
    public class DataAccessLayerModule : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<DOSContext>();
        }
    }
}
