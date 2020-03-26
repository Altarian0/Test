namespace FunctionTestApp.Database
{
    public abstract class DBHelper
    {
        private static BoatSkillsEntities Context = new BoatSkillsEntities();

        public static BoatSkillsEntities GetContext()
        {
            return Context;
        }
    }
}
