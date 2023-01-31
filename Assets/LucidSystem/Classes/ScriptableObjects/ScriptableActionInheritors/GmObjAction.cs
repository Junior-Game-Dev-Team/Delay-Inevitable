namespace Lucid
{
    public abstract class GmObjAction : ScriptableAction
    {
        public override string QueryParent()
        {
            return "GmObjAction";
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }

        public override void Execute(string stringval, int intval)
        {
            throw new System.NotImplementedException();
        }
    }
}
