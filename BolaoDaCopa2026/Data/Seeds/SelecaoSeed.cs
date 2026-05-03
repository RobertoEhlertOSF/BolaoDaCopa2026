using BolaoDaCopa2026.Models;
using Microsoft.EntityFrameworkCore;

namespace BolaoDaCopa2026.Data.Seeds
{
    public static class SelecaoSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Selecao>().HasData(

            // =====================
            // GRUPO A
            // =====================
            new Selecao
            {
                Id = 1,
                Nome = "México",
                Grupo = "A",
                BandeiraUrl = "https://flagcdn.com/w160/mx.png"
            },
            new Selecao
            {
                Id = 2,
                Nome = "África do Sul",
                Grupo = "A",
                BandeiraUrl = "https://flagcdn.com/w160/za.png"
            },
            new Selecao
            {
                Id = 3,
                Nome = "Coreia do Sul",
                Grupo = "A",
                BandeiraUrl = "https://flagcdn.com/w160/kr.png"
            },
            new Selecao
            {
                Id = 4,
                Nome = "República Tcheca",
                Grupo = "A",
                BandeiraUrl = "https://flagcdn.com/w160/cz.png"
            },

            // =====================
            // GRUPO B
            // =====================
            new Selecao
            {
                Id = 5,
                Nome = "Canadá",
                Grupo = "B",
                BandeiraUrl = "https://flagcdn.com/w160/ca.png"
            },
            new Selecao
            {
                Id = 6,
                Nome = "Bósnia",
                Grupo = "B",
                BandeiraUrl = "https://flagcdn.com/w160/ba.png"
            },
            new Selecao
            {
                Id = 7,
                Nome = "Catar",
                Grupo = "B",
                BandeiraUrl = "https://flagcdn.com/w160/qa.png"
            },
            new Selecao
            {
                Id = 8,
                Nome = "Suíça",
                Grupo = "B",
                BandeiraUrl = "https://flagcdn.com/w160/ch.png"
            },

            // =====================
            // GRUPO C
            // =====================
            new Selecao
            {
                Id = 9,
                Nome = "Brasil",
                Grupo = "C",
                BandeiraUrl = "https://flagcdn.com/w160/br.png"
            },
            new Selecao
            {
                Id = 10,
                Nome = "Marrocos",
                Grupo = "C",
                BandeiraUrl = "https://flagcdn.com/w160/ma.png"
            },
            new Selecao
            {
                Id = 11,
                Nome = "Haiti",
                Grupo = "C",
                BandeiraUrl = "https://flagcdn.com/w160/ht.png"
            },
            new Selecao
            {
                Id = 12,
                Nome = "Escócia",
                Grupo = "C",
                BandeiraUrl = "https://flagcdn.com/w160/gb-sct.png"
            },
            // =====================
            // GRUPO D
            // =====================
            new Selecao
            {
                Id = 13,
                Nome = "Estados Unidos",
                Grupo = "D",
                BandeiraUrl = "https://flagcdn.com/w160/us.png"
            },
            new Selecao
            {
                Id = 14,
                Nome = "Paraguai",
                Grupo = "D",
                BandeiraUrl = "https://flagcdn.com/w160/py.png"
            },
            new Selecao
            {
                Id = 15,
                Nome = "Austrália",
                Grupo = "D",
                BandeiraUrl = "https://flagcdn.com/w160/au.png"
            },
            new Selecao
            {
                Id = 16,
                Nome = "Turquia",
                Grupo = "D",
                BandeiraUrl = "https://flagcdn.com/w160/tr.png"
            },

            // =====================
            // GRUPO E
            // =====================
            new Selecao
            {
                Id = 17,
                Nome = "Alemanha",
                Grupo = "E",
                BandeiraUrl = "https://flagcdn.com/w160/de.png"
            },
            new Selecao
            {
                Id = 18,
                Nome = "Curaçao",
                Grupo = "E",
                BandeiraUrl = "https://flagcdn.com/w160/cw.png"
            },
            new Selecao
            {
                Id = 19,
                Nome = "Costa do Marfim",
                Grupo = "E",
                BandeiraUrl = "https://flagcdn.com/w160/ci.png"
            },
            new Selecao
            {
                Id = 20,
                Nome = "Equador",
                Grupo = "E",
                BandeiraUrl = "https://flagcdn.com/w160/ec.png"
            },

            // =====================
            // GRUPO F
            // =====================
            new Selecao
            {
                Id = 21,
                Nome = "Holanda",
                Grupo = "F",
                BandeiraUrl = "https://flagcdn.com/w160/nl.png"
            },
            new Selecao
            {
                Id = 22,
                Nome = "Japão",
                Grupo = "F",
                BandeiraUrl = "https://flagcdn.com/w160/jp.png"
            },
            new Selecao
            {
                Id = 23,
                Nome = "Suécia",
                Grupo = "F",
                BandeiraUrl = "https://flagcdn.com/w160/se.png"
            },
            new Selecao
            {
                Id = 24,
                Nome = "Tunísia",
                Grupo = "F",
                BandeiraUrl = "https://flagcdn.com/w160/tn.png"
            },

            // =====================
            // GRUPO G
            // =====================
            new Selecao
            {
                Id = 25,
                Nome = "Bélgica",
                Grupo = "G",
                BandeiraUrl = "https://flagcdn.com/w160/be.png"
            },
            new Selecao
            {
                Id = 26,
                Nome = "Egito",
                Grupo = "G",
                BandeiraUrl = "https://flagcdn.com/w160/eg.png"
            },
            new Selecao
            {
                Id = 27,
                Nome = "Irã",
                Grupo = "G",
                BandeiraUrl = "https://flagcdn.com/w160/ir.png"
            },
            new Selecao
            {
                Id = 28,
                Nome = "Nova Zelândia",
                Grupo = "G",
                BandeiraUrl = "https://flagcdn.com/w160/nz.png"
            },
            // =====================
            // GRUPO H
            // =====================
            new Selecao
            {
                Id = 29,
                Nome = "Espanha",
                Grupo = "H",
                BandeiraUrl = "https://flagcdn.com/w160/es.png"
            },
            new Selecao
            {
                Id = 30,
                Nome = "Cabo Verde",
                Grupo = "H",
                BandeiraUrl = "https://flagcdn.com/w160/cv.png"
            },
            new Selecao
            {
                Id = 31,
                Nome = "Arábia Saudita",
                Grupo = "H",
                BandeiraUrl = "https://flagcdn.com/w160/sa.png"
            },
            new Selecao
            {
                Id = 32,
                Nome = "Uruguai",
                Grupo = "H",
                BandeiraUrl = "https://flagcdn.com/w160/uy.png"
            },

            // =====================
            // GRUPO I
            // =====================
            new Selecao
            {
                Id = 33,
                Nome = "França",
                Grupo = "I",
                BandeiraUrl = "https://flagcdn.com/w160/fr.png"
            },
            new Selecao
            {
                Id = 34,
                Nome = "Senegal",
                Grupo = "I",
                BandeiraUrl = "https://flagcdn.com/w160/sn.png"
            },
            new Selecao
            {
                Id = 35,
                Nome = "Iraque",
                Grupo = "I",
                BandeiraUrl = "https://flagcdn.com/w160/iq.png"
            },
            new Selecao
            {
                Id = 36,
                Nome = "Noruega",
                Grupo = "I",
                BandeiraUrl = "https://flagcdn.com/w160/no.png"
            },

            // =====================
            // GRUPO J
            // =====================
            new Selecao
            {
                Id = 37,
                Nome = "Argentina",
                Grupo = "J",
                BandeiraUrl = "https://flagcdn.com/w160/ar.png"
            },
            new Selecao
            {
                Id = 38,
                Nome = "Argélia",
                Grupo = "J",
                BandeiraUrl = "https://flagcdn.com/w160/dz.png"
            },
            new Selecao
            {
                Id = 39,
                Nome = "Áustria",
                Grupo = "J",
                BandeiraUrl = "https://flagcdn.com/w160/at.png"
            },
            new Selecao
            {
                Id = 40,
                Nome = "Jordânia",
                Grupo = "J",
                BandeiraUrl = "https://flagcdn.com/w160/jo.png"
            },

            // =====================
            // GRUPO K
            // =====================
            new Selecao
            {
                Id = 41,
                Nome = "Portugal",
                Grupo = "K",
                BandeiraUrl = "https://flagcdn.com/w160/pt.png"
            },
            new Selecao
            {
                Id = 42,
                Nome = "RD Congo",
                Grupo = "K",
                BandeiraUrl = "https://flagcdn.com/w160/cd.png"
            },
            new Selecao
            {
                Id = 43,
                Nome = "Uzbequistão",
                Grupo = "K",
                BandeiraUrl = "https://flagcdn.com/w160/uz.png"
            },
            new Selecao
            {
                Id = 44,
                Nome = "Colômbia",
                Grupo = "K",
                BandeiraUrl = "https://flagcdn.com/w160/co.png"
            },

            // =====================
            // GRUPO L
            // =====================
            new Selecao
            {
                Id = 45,
                Nome = "Inglaterra",
                Grupo = "L",
                BandeiraUrl = "https://flagcdn.com/w160/gb-eng.png"
            },
            new Selecao
            {
                Id = 46,
                Nome = "Croácia",
                Grupo = "L",
                BandeiraUrl = "https://flagcdn.com/w160/hr.png"
            },
            new Selecao
            {
                Id = 47,
                Nome = "Gana",
                Grupo = "L",
                BandeiraUrl = "https://flagcdn.com/w160/gh.png"
            },
            new Selecao
            {
                Id = 48,
                Nome = "Panamá",
                Grupo = "L",
                BandeiraUrl = "https://flagcdn.com/w160/pa.png"
            });
        }
    }
}