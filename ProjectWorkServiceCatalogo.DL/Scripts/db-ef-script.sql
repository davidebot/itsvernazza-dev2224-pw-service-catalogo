﻿CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20231108092611_db-init') THEN
    CREATE TABLE "CATEGORIA" (
        "ID" bigint GENERATED BY DEFAULT AS IDENTITY,
        "NOME" character varying(100) NOT NULL,
        CONSTRAINT "PK_CATEGORIA" PRIMARY KEY ("ID")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20231108092611_db-init') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20231108092611_db-init', '6.0.24');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20231109133907_add-prodotto') THEN
    CREATE TABLE "PRODOTTO" (
        "ID" bigint GENERATED BY DEFAULT AS IDENTITY,
        "NOME" character varying(100) NOT NULL,
        "FK_CATEGORIA" bigint NOT NULL,
        "PREZZO" numeric NOT NULL,
        "PESO" numeric NULL,
        "DISPONIBILITA" integer NOT NULL,
        "DESCRIZIONE" text NULL,
        "IMMAGINE" text NULL,
        "MATERIALE" text NULL,
        CONSTRAINT "PK_PRODOTTO" PRIMARY KEY ("ID"),
        CONSTRAINT "FK_PRODOTTO_CATEGORIA_FK_CATEGORIA" FOREIGN KEY ("FK_CATEGORIA") REFERENCES "CATEGORIA" ("ID") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20231109133907_add-prodotto') THEN
    CREATE INDEX "IX_PRODOTTO_FK_CATEGORIA" ON "PRODOTTO" ("FK_CATEGORIA");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20231109133907_add-prodotto') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20231109133907_add-prodotto', '6.0.24');
    END IF;
END $EF$;
COMMIT;

