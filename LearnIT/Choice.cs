using System.Data.SqlTypes;

namespace LearnIT.ClassesAndDB
{
    class Choice
    {
        public SqlInt32 ID;
        public SqlInt32 Q_ID;
        public SqlString ChoiceText;
        public SqlBoolean is_Correct;


        public Choice(SqlInt32 ID, SqlInt32 Q_ID, SqlString ChoiceText, SqlBoolean is_Correct)
        {
            this.ID = ID;
            this.Q_ID = Q_ID;
            this.ChoiceText = ChoiceText;
            this.is_Correct = is_Correct;

        }
    }
}
