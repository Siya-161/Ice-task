using System;

namespace MarkingApp

{
    public class Inputs
    {
         
        private int totalScripts;
        private int noOfQuestions;
        private int questionSubtotal;
        private int noOfLecturers;

        public void setTotalScripts(int noOfScripts)
        {
            totalScripts = noOfScripts;
        }

        public int getTotalScripts()
        {
            return totalScripts;
        }

        public void setNoOfQuestions(int numOfQs)
        {
            noOfQuestions = numOfQs;
        }

        public int getNoOfQuestions()
        {
            return noOfQuestions;
        }

        public void setQuestionSubtotal(int qSubtotal)
        {
            questionSubtotal = qSubtotal;
        }

        public int getQuestionSubtotal()
        {
            return questionSubtotal;
        }
        public void setNoOfLecturers(int lecturers)
        {
            noOfLecturers = lecturers;
        }

        public int getNoOfLecturers()
        {
            return noOfLecturers;
        }


    }

    public class Driver
    {
        public static void Main(string[] args)
        {
            Inputs i1 = new Inputs();
            scripts(i1);
            questions(i1);
            subtotals(i1, i1.getNoOfQuestions());
            noOfLecturers(i1);

            workDivison(i1);

        }

        public static void scripts(Inputs i1)
        {
            int input;

            Console.WriteLine("Enter the total number of scripts to be marked: ");

            input = Convert.ToInt32(Console.ReadLine());

            if (input <= 0)
            {
                Console.WriteLine("The value must be greater than 0");

                while (input <= 0)
                {
                    Console.WriteLine("Enter the total number of scripts to be marked: ");
                    input = Convert.ToInt32(Console.ReadLine());
                    if (input <= 0)
                    {
                        Console.WriteLine("The value must be greater than 0");
                    }
                    else if (input > 0)
                    {
                        i1.setTotalScripts(input);
                    }
                }
            }
            else  
            {
                i1.setTotalScripts(input);
            }


            //return i1;

        }

        public static void questions(Inputs i1)
        {
            int input;
            Console.WriteLine("Enter the total number of questions constituting the test: ");

            input = Convert.ToInt32(Console.ReadLine());
            if (input < 1 || input > 10)
            {
                Console.WriteLine("The value must be equal to or greater than one and less than 10");

                while (input < 1 || input > 10)
                {
                    Console.WriteLine("Enter the total number of questions constituting the test: ");
                    input = Convert.ToInt32(Console.ReadLine());
                    if (input < 1 || input > 10)
                    {
                        Console.WriteLine("The value must be equal to or greater than one and less than 10");
                    }
                    else if(input > 1 & input < 10)
                    {
                        i1.setNoOfQuestions(input);
                    }
                }
            }
            else
            {
                i1.setNoOfQuestions(input);
            }

           
        }

        public static void subtotals(Inputs i1, int noOfQuestions)
        {

            int questionSubTotal = 0;


            for (int index =0 ; index< noOfQuestions;index++)
            {
                

                int input;
                Console.WriteLine("Enter the subtotal of question {0}: ", (index+1));
                input = Convert.ToInt32(Console.ReadLine());
                if (input <= 0)
                {
                    Console.WriteLine("The value must be greater than 0");

                    while (input <= 0)
                    {
                        Console.WriteLine("Enter the subtotal of question {0}: ", (index + 1));
                        input = Convert.ToInt32(Console.ReadLine());
                        if (input <= 0)
                        {
                            Console.WriteLine("The value must be greater than 0");
                        }
                        else if (input > 0)
                        {
                            questionSubTotal += input;
 

                                i1.setQuestionSubtotal(questionSubTotal);
                             
                            
                        }
                    }
                }
                else
                {
                    i1.setQuestionSubtotal(input);
                }
            }
            

            





        }

        public static void noOfLecturers(Inputs i1)
        {
            Console.WriteLine("Enter the number of lecturers: ");

            int input = Convert.ToInt32(Console.ReadLine());

            if (input <= 0)
            {
                Console.WriteLine("The value must be greater than 0");

                while (input <= 0)
                {
                    Console.WriteLine("Enter the number of lecturers: ");
                    input = Convert.ToInt32(Console.ReadLine());
                    if (input <= 0)
                    {
                        Console.WriteLine("The value must be greater than 0");
                    }
                    else if (input > 0)
                    {
                        i1.setNoOfLecturers(input);
                    }
                }
            }
            else
            {
                i1.setNoOfLecturers(input);
            }
        }

        public static void workDivison(Inputs i1)
        {
            //int scriptsTotal = i1.getTotalScripts();
            //int lecturersTotal = i1.getNoOfLecturers();

            int scriptsPerlecturer = i1.getTotalScripts()/ i1.getNoOfLecturers();

            Console.WriteLine("Each lecturer is going to mark at least {0} scripts", scriptsPerlecturer);

            int[] lecturerScripts = new int[i1.getNoOfLecturers()];

            for(int i = 0; i < lecturerScripts.Length; i++)
            {
                lecturerScripts[i] = scriptsPerlecturer;
                if (i ==   lecturerScripts.Length - 1 )
                {
                    lecturerScripts[i] = lecturerScripts[i] + (i1.getTotalScripts() %i1.getNoOfLecturers());
                }

                Console.WriteLine("Lecturer {0} : {1}", (i +1),lecturerScripts[i]);
            }

            int[] estimatedHours = new int[i1.getNoOfLecturers()];
            double[] estimatedMins = new double[i1.getNoOfLecturers()];
             
            int ticksPerScript;

            ticksPerScript =  i1.getNoOfQuestions() * i1.getQuestionSubtotal() ;

            for (int index = 0; index < lecturerScripts.Length; index++) 
            {

                estimatedMins[index] = ((ticksPerScript * lecturerScripts[index])*2)/60;
                  

                if ((estimatedMins[index] % 1) >= 0.5)
                  {
                     estimatedMins[index] = +1;
                    }

                if (estimatedMins[index] >= 60)
                {
                    estimatedHours[index] = (int)(estimatedMins[index]/60);

                    estimatedMins[index] = estimatedMins[index] - (estimatedHours[index] * 60);

                    
                     
                     
                }
               
                Console.WriteLine(" Estimated time it will take Lecturer {0} to mark their scripts : {1} hours and {2} minutes", (index + 1), estimatedHours[index], estimatedMins[index] );
            }
           
        }

       

    }
}

