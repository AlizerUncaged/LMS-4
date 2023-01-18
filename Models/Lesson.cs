namespace HOME.Models
{
    public class Lesson
    {
        
        public int LessonId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Content { get; set; }
    }
}
/*
 
 question lang po possible naman po yung flow po na dapat mabasa muna ng user yung lesson before mabuksan yung quizz na para po doon diba po?
 
x yung flow po ng site dapat po pag nabasa po yung gantong lesson, tsaka lang po maaaccess ng student yung isang quiz

admin homepage (kulang yung buttons po ng add edit delete lesson, add edit delete quiz, add delete category)

quiz page (makikita mga students na nagtake and yung score nila)

admin quiz add edit (magaadd po ng quiz or edit existing quiz and may settings po siya para po sa timer ng quiz

quiz page (kulang po siya ng timer)

admin lesson add edit (add or edit existing lesson)

manage accounts page ( makikita po mga users and pwede po masuspend account)

student homepage(mapakita po yung quiz na di pa nasasagutan ng student sa header)

certificate page (maggegenerate ng certificate pag natake na po ng student lahat ng quiz sa isang category tas masstore po sa isang page mga certificate na 
natanggap ng student)

*/