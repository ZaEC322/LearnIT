using System.Data.SqlTypes;

namespace LearnIT
{
    internal class Question
    {
        public SqlInt32 ID;
        public SqlString QuestionText;

        public Question(SqlInt32 ID, SqlString QuestionText)
        {
            this.ID = ID;
            this.QuestionText = QuestionText;
        }
    }
}