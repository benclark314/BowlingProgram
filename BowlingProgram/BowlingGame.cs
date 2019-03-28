using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingProgram
{
    public class BowlingGame
    {
        /*
         * 
         * Instance variables
         * 
         */
        //2-dimensional array with {frame, shot}:
        public int[,] shotValue = new int[10, 2];

        //The running game score:
        public int gameScore;

        //The value of the additional shot at the end of the game:
        public int additionalShotValue;

        //A flag for invalid data:
        public bool invalidEntryFlag;




        /*
         * 
         * 
         * Default constructor
         * 
         * 
         */
        public BowlingGame()
        {
            //Initialize the instance variables:
            gameScore = 0;
            additionalShotValue = 0;
            invalidEntryFlag = false;
            additionalShotValue = 0;

            //Populate the array with 0's
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    shotValue[i,j] = 0;
                }
            }
        }


        //Compute and return the score for the given game:
        public int computeScore()
        {
            gameScore = 0;

            //Iterate through all frames
            for (int i = 0; i < 10; i++)
            {
                //Add the value for the current frame to the total:
                gameScore += shotValue[i, 0];
                gameScore += shotValue[i, 1];

                //If the current frame was a strike, add the sum of the next two values:
                if (frameHadStrike(i + 1))
                {
                    gameScore += nextTwoShotsSum(i + 1);
                }
                //If the frame was a spare, add the next value:
                if (frameHadSpare(i + 1))
                {
                    gameScore += nextShotValue(i + 1, 2);
                }
            }
            return gameScore;
        }


        //Returns TRUE if the user enters an invalid string.
        public bool hasInvalidEntry()
        {
            if(invalidEntryFlag)
            {
                invalidEntryFlag = false;
                return true;
            }
            else
            {
                return false;
            }
        }


        //Returns TRUE if the user enters values totaling more than 10 for a given frame.
        public bool frameExceedsTenPoints()
        {
            bool framePointsFlag = false;

            for (int i = 0; i < 9; i++)
            {
                if (shotValue[i, 0] + shotValue[i, 1] > 10)
                {
                    framePointsFlag = true;
                }
            }
            return framePointsFlag;
        }


        //Returns TRUE if a given frame had a strike:
        public bool frameHadStrike(int frameNumber)
        {
            if(shotValue[frameNumber - 1, 0] == 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Returns true if a given frame had a spare:
        public bool frameHadSpare(int frameNumber)
        {
            if(shotValue[frameNumber - 1, 0] != 10 && shotValue[frameNumber - 1, 0] != 10)
            {
                if (shotValue[frameNumber - 1, 0] + shotValue[frameNumber - 1, 1] == 10)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        //Return the sum of the next two shots after a strike, given the strike's frame.
        public int nextTwoShotsSum(int frameNumber)
        {
            int sum = 0;

            if (frameNumber < 10)
            {
                sum += shotValue[frameNumber, 0];
                sum += nextShotValue(frameNumber+1, 1);
                return sum;
            }
            else
            {
                sum += shotValue[frameNumber-1, 1];
                sum += additionalShotValue;
                return sum;
            }
        }


        //Return the value of the next shot, given a frame and shot.
        public int nextShotValue(int frameNumber, int shot)
        {
            if(frameNumber < 10)
            {
                //If you got a strike or you are on the second shot, the next shot is the first shot in the next frame:
                if (shotValue[frameNumber - 1, 0] == 10 || shot == 2)
                {
                    return shotValue[frameNumber, 0];
                }
                //If you didn't get a strike and you are on the first shot, the next shot is the second one in this frame.
                else
                {
                    return shotValue[frameNumber-1, 1];
                }
            }
            else if (frameNumber == 10)
            {
                //If you are on the first shot, the next shot is the second one:
                if (shot == 1)
                {
                    return shotValue[frameNumber-1, 1];
                }
                //If you are on the second shot, the next shot is the additional one:
                else
                {
                    return additionalShotValue;
                }
            }
            else
            {
                return 0;
            }
        }


        //Enter values into shotValue array:
        public void setShotValue(int frameNumber, int shotNumber, string textValueEntered)
        {
            if (int.TryParse(textValueEntered, out int value))
            {
                if (value < 0 || value > 10)
                {
                    invalidEntryFlag = true;
                }
                else
                {
                    shotValue[frameNumber - 1, shotNumber - 1] = value;
                }
            }
            else if (!(string.IsNullOrEmpty(textValueEntered)))
            {
                invalidEntryFlag = true;
            }
            else if (string.IsNullOrEmpty(textValueEntered))
            {
                shotValue[frameNumber - 1, shotNumber - 1] = 0;
            }
        }


        //Set the value of the additional shot on the tenth frame:
        public void setAdditionalShotValue(string additionalShot)
        {
            if (int.TryParse(additionalShot, out int value))
            {
                if (value < 0 || value > 10)
                {
                    invalidEntryFlag = true;
                }
                else
                {
                    additionalShotValue = value;
                }
            }
            else if (!(string.IsNullOrEmpty(additionalShot)))
            {
                invalidEntryFlag = true;
            }
        }


        //Given the entries for the tenth frame, return TRUE if the player gets an additional shot:
        public bool playerGetsAddionalShot(string lastFrameFirstShot, string lastFrameSecondShot)
        {
            if (int.TryParse(lastFrameFirstShot, out int i) && int.TryParse(lastFrameSecondShot, out int j))
            {
                if (i + j == 10)
                {
                    return true;
                }
                else if (i == 10)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (int.TryParse(lastFrameFirstShot, out int k))
            {
                if (k == 10)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (int.TryParse(lastFrameSecondShot, out int l))
            {
                if (l == 10)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
