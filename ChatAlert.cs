using System.Text.RegularExpressions;

namespace CampahApp
{
    using EliteMMO.API;

    public enum ChatMode
    {
        Error = -1,				// "Invented" chat mode, to help catch errors
        Generic = 0,		// Unknown = 0,			 // Catch all. it's not a catch all.

        //--------------------------------------------------------------'
        //-Text That's Been Sent To The ChatLog By You aKa (The Player-)'
        //--------------------------------------------------------------'
        SentSay = 1,			 // = a say message that the user sends
        SentShout = 2,         // = a shout message that the user sends
        SentYell = 3,
        SentTell = 4,			// = user sends tell to someone else
        SentParty = 5,		   // = user message to Party
        SentLinkShell = 6,	   // = user message to linkshell
        SentEmote = 7,			  // = user uses /emote

        //--------------------------------------------------------------'
        //----Text That's Been Recieved In ChatLog By Other Players-----'
        //--------------------------------------------------------------'
        RcvdSay = 9,			 // = a say mesage the user recieves from someone else
        RcvdShout = 10,       // = incoming shout
        RcvdYell = 11,
        RcvdTell = 12,		   // = incoming tell
        RcvdParty = 13,		  // = incoming party message
        RcvdLinkShell = 14,	  // = incoming linkshell text
        RcvdEmote = 15,          // = received Emote
                                 // Yell???

        //--------------------------------------------------------------'
        //-----------You aKa (The Player's) Fight Log Stuff-------------'
        //--------------------------------------------------------------'
        PlayerHits = 20,	// eg. Player hits the Thread Leech for XX points of damage.
        PlayerMisses = 21,
        TargetUsesJobAbility = 22, // eg. The Thread Leech uses TP Drainkiss.
        SomeoneRecoversHP = 23,
        TargetHits = 28,	 // eg. The Thread Leech hits Player for XX points of damage.
        TargetMisses = 29,	   // eg. The Thread Leech misses Player.
        PlayerAdditionalEffect = 30,
        PlayerRecoversHP = 31,		// Player casts Cure. Player recovers 30 HP.
        PlayerDefeats = 36,	  // eg. Player Defeats the T
        PlayedDefeated = 38,
        NPCHit = 40,
        NPCMiss = 41,
        NPCSpellEffect = 42,
        SomeoneSpellEffect = 43,
        SomeoneDefeats = 44,	 // = somebody "defeats the" river crab or whatever
        PlayerCastComplete = 50,
        PartySpellEffect = 51,
        PlayerStartCasting = 52, // eg. Player starts casting Dia on the Thread Leech., The Antican Princeps starts casting Flash.
        PlayerSpellResult = 56,
        PlayerRcvdEffect = 57, // The Antican Princeps casts Flash. <name> is blinded.
        PlayerSpellResist = 59,
        PlayerSpellEffect = 64,
        TargetEffectOff = 65,
        SomeoneNoEffect = 69,
        PlayerLearnedSpell = 81,
        Itemused = 90,
        SomeoneItemBadEffect = 91,
        SomeoneItemGoodEfect = 92,
        TargetActionStart = 100,
        PlayerUsesJobAbility = 101, // eg. Player uses Divine Seal.
        PlayerStatusResult = 102,
        TargetActionMiss = 104,
        PlayerReadiesMove = 110, // eg. The Thread Leech readies Brain Drain.
        SomeoneAbility = 111,
        SomeoneBadEffect = 112,
        PlayerWSMiss = 114,
        SynthResult = 121,	   // = you throw away a rusty subligar or whatever
        PlayersBadCast = 122,	// eg. Inturrupted or Unable to Cast. eg: Unable To Cast That Spell
        TellNotRcvd = 123,	   // = your tell was not received
        Obtained = 127,
        SkillBoost = 129,		// = you fishing skill rises 0.1 points
        Experience = 131,
        ActionStart = 135,
        LogoutMessage = 136,
        ItemSold = 138,		  // = item sold
        ClockInfo = 140,
        MoogleYellow = 141,
        NPCChat = 142,
        MoogleWhite = 144,
        FishObtained = 146,	  // "player caught ....!"
        FishResult = 148,		// = fishing result including: 
        NPCSpeaking = 152,	  // = something caught on hook... incorrect, NPC speaking to you
        CommandError = 157,	  // = A command error occurred
        DropRipCap = 159,		// = you release the ripped cap regretfully
        RegConquest = 161,	   // = regional conquest update message
        ChangeJob = 190,
        EffectWearOff = 191,	 // eg. Player's Protect effect wears off
        ServerNotice = 200,	   // = notice of upcoming server maintenance
        SearchComment = 204,
        LSMES = 205,
        Echo = 206,			  // = echo
        Examined = 208,
        AbilTimeLeft = 209    // Time left on "job ability"
    } // @ public enum ChatMode : short

    class ChatAlert
    {
        public ChatAlert(Regex condition)
        {
            Condition = condition;
            Completed = false;
            Mode = (int)ChatMode.Generic;
        }

        private Regex Condition { get; set; }

        public Match Result { get; private set; }

        public bool Completed { get; private set; }

        public int Mode { get; private set; }
       
        public bool ParseLine(EliteAPI.ChatEntry line)
        {
            Result = Condition.Match(line.Text);            
            return (Completed = Condition.IsMatch(line.Text));
        }
    }
}