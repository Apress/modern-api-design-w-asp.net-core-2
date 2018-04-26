namespace AwesomeSauce.Api
{
    public interface IComponent
    {
        string Name { get; }
    }
    public class ComponentA
    {
        private readonly IComponent _componentB;
        public ComponentA(IComponent componentB)
        {
            this._componentB = componentB;
        }
    }
    public class ComponentB : IComponent
    {
        public string Name { get; set; } = nameof(ComponentB);
    }

}
