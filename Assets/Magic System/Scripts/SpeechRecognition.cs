using System.Collections;
using System.Collections.Generic;
using UnityEngine.Windows.Speech;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class SpeechRecognition : MonoBehaviour
{
    //Flagellum whip like magic weapon, lumen light spell, obscuro light stop, vulnus combat spell
    //public string[] spells = new string[] { "flagellum", "lumen", "obscurus", "vulnus","pervenio" };

    public Dictionary<string, UnityAction> spells = new Dictionary<string, UnityAction>();


    public ConfidenceLevel confidence = ConfidenceLevel.Low;


    //DictationTopicConstraint topic = DictationTopicConstraint.Dictation;
    KeywordRecognizer recognizer;
    //DictationRecognizer dictation;
    SpellManager sm;

    private GrammarRecognizer grammarRecognizer;

    private void Awake()
    {
        spells.Add("lumen", Lumen);
        spells.Add("obscuro",Obscuro);
        spells.Add("vulnus", Vulnus);
        spells.Add("apporto", Apporto);
        spells.Add("repulso", Repulso);
        spells.Add("finis", Finis);
        spells.Add("pendeo", Pendeo);
        spells.Add("statis", Statis);
        spells.Add("libera", Libera);

    }



    private void Start()
    {
        sm = GameObject.Find("SpellManager").GetComponent<SpellManager>();
        //dictation = new DictationRecognizer(confidence, topic);
        //grammarRecognizer = new GrammarRecognizer(spells.Keys.ToString());
        recognizer = new KeywordRecognizer(spells.Keys.ToArray(), confidence);

        recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
        //grammarRecognizer.OnPhraseRecognized += Grammar_OnPhraseRecognized;

        //recognizer.RecognizeAsync(RecognizeMode.Multiple);
        //grammarRecognizer.Start();
        recognizer.Start();



    }
    
    private void Apporto()
    {
        sm.Spell_Apporto();
        Debug.Log("Apporto!");

    }
    private void Pendeo()
    {
        sm.Spell_Pendeo();
        Debug.Log("Pendeo!");
    }
    private void Lumen()
    {
        sm.Spell_Lumen();
        Debug.Log("Lumen!");
    }
    private void Obscuro()
    {
        sm.Spell_Obscuro();
        Debug.Log("Obscuro!");
    }

    private void Vulnus()
    {
        sm.Spell_Vulnus();
        Debug.Log("Vulnus!");
    }
    private void Repulso()
    {
        sm.Spell_Repulso();
        Debug.Log("Repulso!");
    }
    private void Finis()
    {
        sm.Spell_Finis();
        Debug.Log("Finis!");
    }
    private void Statis()
    {
        sm.Spell_Statis();
        Debug.Log("Statis!");
    }

    private void Libera()
    {
        sm.Spell_Libera();
        Debug.Log("Libera!");
    }



    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {

        spells[args.text].Invoke();
        Debug.Log(args.text);
    }

    //private void Grammar_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    //{
    //    SemanticMeaning[] meanings = args.semanticMeanings;
    //    spells[args.text].Invoke();
    //    // do something
    //}

    private void OnApplicationQuit()
    {
        if (recognizer != null && recognizer.IsRunning)
        {
            recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            recognizer.Stop();
        }




    }


}
