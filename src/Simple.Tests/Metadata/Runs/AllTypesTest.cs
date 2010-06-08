﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Simple.Migrator.Fluent;
using Simple.Migrator.Framework;


namespace Simple.Tests.Metadata.Runs
{
    public class AllTypesTest : BaseTest
    {
        public AllTypesTest(DatabasesXml.Entry entry) : base(entry) { }

        [Migration(1)]
        public class Migration : FluentMigration
        {
            public override void Up()
            {
                Schema.AddTable("t_rel_1", false, t =>
                {
                    t.AddAnsiString("fieldAnsiString").PrimaryKey();
                    t.AddBinary("fieldBinary").PrimaryKey();
                    t.AddByte("fieldByte").PrimaryKey();
                    t.AddBoolean("fieldBoolean").PrimaryKey();
                    t.AddCurrency("fieldCurrency").PrimaryKey();
                    t.AddDateTime("fieldDateTime").PrimaryKey();
                    t.AddDecimal("fieldDecimal").PrimaryKey();
                    t.AddDouble("fieldDouble").PrimaryKey();
                    t.AddInt16("fieldInt16").PrimaryKey();
                    t.AddInt32("fieldInt32").PrimaryKey();
                    t.AddInt64("fieldInt64").PrimaryKey();
                    t.AddSingle("fieldSingle").PrimaryKey();
                    t.AddString("fieldString").PrimaryKey();
                });

                Schema.AddTable("t_rel_2", false, t =>
                {
                    t.AutoForeignKey("t_rel_1"
                                        , t.AddAnsiString("fieldAnsiString").PrimaryKey()
                                        , t.AddBinary("fieldBinary").PrimaryKey()
                                        , t.AddByte("fieldByte").PrimaryKey()
                                        , t.AddBoolean("fieldBoolean").PrimaryKey()
                                        , t.AddCurrency("fieldCurrency").PrimaryKey()
                                        , t.AddDateTime("fieldDateTime").PrimaryKey()
                                        , t.AddDecimal("fieldDecimal").PrimaryKey()
                                        , t.AddDouble("fieldDouble").PrimaryKey()
                                        , t.AddInt16("fieldInt16").PrimaryKey()
                                        , t.AddInt32("fieldInt32").PrimaryKey()
                                        , t.AddInt64("fieldInt64").PrimaryKey()
                                        , t.AddSingle("fieldSingle").PrimaryKey()
                                        , t.AddString("fieldString").PrimaryKey()
                                        );

                });

            }

            public override void Down()
            {
                Schema.RemoveTable("t_rel_2");
                Schema.RemoveTable("t_rel_1");
            }
        }

        public override IEnumerable<Type> GetMigrations()
        {
            yield return typeof(Migration);
        }



        public override IEnumerable<TableAddAction> GetTableDefinitions()
        {
            yield return TableDef("t_rel_1", t =>
            {
                t.AddAnsiString("fieldAnsiString").PrimaryKey();
                t.AddBinary("fieldBinary").PrimaryKey();
                t.AddByte("fieldByte").PrimaryKey();
                t.AddBoolean("fieldBoolean").PrimaryKey();
                t.AddCurrency("fieldCurrency").PrimaryKey();
                t.AddDateTime("fieldDateTime").PrimaryKey();
                t.AddDecimal("fieldDecimal").PrimaryKey();
                t.AddDouble("fieldDouble").PrimaryKey();
                t.AddInt16("fieldInt16").PrimaryKey();
                t.AddInt32("fieldInt32").PrimaryKey();
                t.AddInt64("fieldInt64").PrimaryKey();
                t.AddSingle("fieldSingle").PrimaryKey();
                t.AddString("fieldString").PrimaryKey();
            });

            yield return TableDef("t_rel_2", t =>
            {
                t.ForeignKey("t_rel_2_t_rel_1_fk", "t_rel_1", t.AddAnsiString("fieldAnsiString").PrimaryKey()
                                    , t.AddBinary("fieldBinary").PrimaryKey()
                                    , t.AddByte("fieldByte").PrimaryKey()
                                    , t.AddBoolean("fieldBoolean").PrimaryKey()
                                    , t.AddCurrency("fieldCurrency").PrimaryKey()
                                    , t.AddDateTime("fieldDateTime").PrimaryKey()
                                    , t.AddDecimal("fieldDecimal").PrimaryKey()
                                    , t.AddDouble("fieldDouble").PrimaryKey()
                                    , t.AddInt16("fieldInt16").PrimaryKey()
                                    , t.AddInt32("fieldInt32").PrimaryKey()
                                    , t.AddInt64("fieldInt64").PrimaryKey()
                                    , t.AddSingle("fieldSingle").PrimaryKey()
                                    , t.AddString("fieldString").PrimaryKey()
                                    );

            });


        }
    }
}

