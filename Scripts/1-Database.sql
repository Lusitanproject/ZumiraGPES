use master
go
CREATE DATABASE DB_GPES ON  PRIMARY 
    ( NAME = N'DB_GPES', FILENAME = N'F:\DB_GPES\DB_GPES.mdf' , SIZE = 302016KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1%)
     LOG ON 
    ( NAME = N'DB_GPES_Log', FILENAME = N'F:\DB_GPES\DB_GPES_Log.ldf' , SIZE = 1714560KB , MAXSIZE = 2048GB , FILEGROWTH = 1% )
    GO