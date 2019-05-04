namespace SlimeScience
{
    public class SlimeBalance
    {

        public int maxSlimes = 5;
        public int currentLevel = 1;

        public void StartGame (string sceneName, int level)
        {
            //Change scenes unity
            //ReloadBoard();
            //CreateLevel(level);
        }

        public void CheckLogic () // When called, checks the board state for a completion.
        {
		    // if sum of all slimes on left = sum of all slimes on right
            // CONTINUE
            // else
            // DECLINE
	    }

        public void ReloadBoard () // Resets all variables
        {
		    //
	    }

        public void CreateLevel (int level) // Loads the backend logic for the checking of the slimes on board
        {
            
        }


    }
}
