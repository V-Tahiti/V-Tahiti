using _1_Random.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1_Random.Services
{
    public class NameServiceList
    {
        private readonly RandomService randomService = new RandomService();

        private readonly List<string> boys = new List<string> {
            "Aaron","Abdullah","Abel","Abigail",
            "Abraham","Achille","Adam","Adame",
            "Adel","Adem","Adil","Adonis",
            "Adrian","Adriano","Adrien","Ahmed",
            "Aiden","Aime","Aimen","Akim",
            "Alain","Alan","Alann","Alban",
            "Alberic","Albert","Albin","Alcide",
            "Aldric","Alec","Alessandro","Alessio",
            "Alex","Alexander","Alexandre","Alexi",
            "Alexis","Alexy","Alfred","Alix",
            "Allan","Aloïs","Aloys","Alvin",
            "Amadou","Amaël","Amaury","Ambroise",
            "Amin","Amine","Amir","Anaël",
            "Anas","Anatole","Anderson","Andoni",
            "André","Andréa","Andréas","Andrew",
            "Andy","Ange","Angelo","Anis",
            "Aniss","Annibal","Anouar","Anselme",
            "Anthonin","Anthony","Antoine","Anton",
            "Antoni","Antonin","Antonio","Antony",
            "Apollinaire","Ariel","Aristide","Armand",
            "Armel","Arnaud","Arno","Arsene",
            "Arthur","Arthus","Artus","Aubert",
            "Aubin","Aubry","Audric","Auguste",
            "Augustin","Aurèle","Aurélien","Austin",
            "Auxence","Avery","Axel","Aymen",
            "Aymeric","Aymerick","Ayrton","Aziz"
        };

        private readonly List<string> girls = new List<string> {
            "Aaron","Abel","Abélard","Abélia",
            "Abella","Abigaël","Abigaëlle","Abondance",
            "Abraham","Achille","Ada","Adam",
            "Adélaïde","Adèle","Adelie","Adeline",
            "Adelle","Adelphe","Adhémar","Adnette",
            "Adolphe","Adriana","Adrien","Adrienne",
            "Aeticia","Agathe","Aglaé","Agnès",
            "Agrippine","Aïcha","Aïda","Aimable",
            "Aimé","Aimée","Alain","Alban",
            "Albane","Albert","Alberta","Alberte",
            "Albertine","Albin","Aldo","Alette",
            "Alex","Alexa","Alexandre","Alexandrine",
            "Alexane","Alexanne","Alexia","Alexiane",
            "Alexina","Alexis","Alfred","Alfreda",
            "Alia","Alice","Alicia","Alida",
            "Aliénor","Aline","Alison","Alissa",
            "Alissia","Alisson","Alix","Aliya",
            "Alizé","Alizée","Allison","Alodie",
            "Aloïs","Alphonse","Alphonsine","Alya",
            "Alycia","Alyson","Alyssa","Alyssia",
            "Alysson","Amaia","Amal","Amalia",
            "Amanda","Amandine","Ambre","Ambrine",
            "Ambroise","Ambroisine","Amédée","Amélia",
            "Amélie","Améline","Amelle","Amina",
            "Amira","Amos","Amy","Ana",
            "Anaë","Anaël","Anaëlle","Anaïs",
            "Anastase","Anastasia","Anastasie","Anastastie",
            "Anatole","André","Andréa","Andrée",
            "Ange","Angéla","Angèle","Angelf",
            "Angélina","Angeline","Angélique","Angie",
            "Anicet","Anis","Anissa","Anita",
            "Anna","Annabelle","Annaëlle","Anne",
            "Anne-Charlotte","Anne-Laure","Anne-Lise","Anne-Marie",
            "Anne-Sophie","Annelie","Annette","Annick",
            "Annie","Anouchka","Anouck","Anouk",
            "Anthéa","Anthony","Antigone","Antoine",
            "Antoinette","Antonin","Anya","Apollinaire",
            "Apolline","Apollos","Appoline","Arabelle",
            "Ariane","Arianne","Arielle","Aristide",
            "Arlette","Armand","Armande","Armel",
            "Armelle","Arnaud","Arnold","Arnould",
            "Arsène","Arthur","Ashley","Asma",
            "Assa","Assia","Astère","Astrid",
            "Athena","Athenais","Aubéri","Aubert",
            "Aubin","Aude","Audrey","Augusta",
            "Augustin","Augustine","Aure","Aurèle",
            "Aurélia","Aurélie","Aurélien","Auréline",
            "Auriane","Aurore","Ava","Axel"
        };

        public string RandomName(Sexes sex)
        {
            if (sex == Sexes.Girl)
                return randomService.GetRandom(girls);
            else
                return randomService.GetRandom(boys);
        }

    }
}
