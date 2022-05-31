create table employee
(
    ID           bigint       default 0  not null
        primary key,
    EmployeeID   varchar(36)             not null,
    FullName     varchar(255)            not null,
    RoleID       smallint(4)  default 0  not null,
    Email        varchar(500)            null,
    PhoneNumber  varchar(50)             null,
    ModifiedDate datetime                null,
    ModifiedBy   varchar(255)            null,
    CreatedDate  datetime                null,
    CreatedBy    varchar(255)            null,
    Username     varchar(255) default '' not null,
    Password     varchar(500) default '' not null,
    FirstName    varchar(100) default '' not null,
    LastName     varchar(100) default '' not null
)
    charset = utf8;

create table issue
(
    ID                 int auto_increment
        primary key,
    TypeID             int                                     null,
    TypeIDText         varchar(255)                            null,
    Subject            varchar(255)                            null,
    PriorityID         int                                     null,
    PriorityIDText     varchar(255)                            null,
    StatusID           int                                     null,
    StatusIDText       varchar(255)                            null,
    AssignedTo         varchar(36)                             null,
    FoundInBuild       varchar(255)                            null,
    IntergratedBuild   varchar(255)                            null,
    CreatedBy          varchar(255) collate utf8mb4_unicode_ci null,
    CreatedDate        datetime                                null,
    ModifiedBy         varchar(255) collate utf8mb4_unicode_ci null,
    ModifiedDate       datetime                                null,
    AssignedUserID     bigint                                  null,
    AssignedUserIDText varchar(255)                            null,
    ProjectID          bigint                                  null,
    ProjectIDText      varchar(255)                            null
)
    charset = utf8;

create table issue_dictionary
(
    ID             bigint auto_increment
        primary key,
    FieldName      varchar(255) not null,
    DictionaryName varchar(255) not null,
    Active         tinyint(1)   null,
    CreatedDate    datetime     null,
    CreatedBy      varchar(255) null,
    ModifiedDate   datetime     null,
    ModifiedBy     varchar(255) null
)
    charset = utf8;

create table issue_dictionary_data
(
    ID           bigint auto_increment
        primary key,
    DictionaryID bigint       not null,
    Value        int          null,
    Text         varchar(255) null,
    Active       tinyint(1)   null,
    SortOrder    int          null,
    CreatedDate  datetime     null,
    CreatedBy    varchar(255) null,
    ModifiedDate datetime     null,
    ModifiedBy   varchar(255) null,
    constraint issue_dictionary_data_ibfk_1
        foreign key (DictionaryID) references issue_dictionary (ID)
)
    charset = utf8;

create index DictionaryID
    on issue_dictionary_data (DictionaryID);

create table project
(
    ID           bigint auto_increment
        primary key,
    ProjectName  varchar(255) default '' not null,
    ProjectCode  varchar(50)  default '' not null,
    ModifiedDate datetime                null,
    ModifiedBy   varchar(255)            null,
    CreatedDate  datetime                null,
    CreatedBy    varchar(255)            null
)
    collate = utf8_unicode_ci;

create
    definer = b7f925ce22548b@`%` procedure Proc_GetDictionaryByFormLayout(IN v_LayoutCode varchar(255))
BEGIN
  DECLARE v_DicTable varchar(255);
  DECLARE v_DicDataTable varchar(255);
  DECLARE v_Query text;

  SET v_DicTable = CONCAT(v_LayoutCode, '_dictionary');
  SET v_DicDataTable = CONCAT(v_LayoutCode, '_dictionary_data');

  SET v_Query = CONCAT('SELECT dtt.* FROM ',v_DicDataTable, 
                    ' dtt JOIN ', v_DicTable, ' dt ON dt.ID = dtt.DictionaryID WHERE dt.FieldName = ''Type''');
  CALL proc_statement(v_Query);

  SET v_Query = CONCAT('SELECT dtt.* FROM ',v_DicDataTable, 
                    ' dtt JOIN ', v_DicTable, ' dt ON dt.ID = dtt.DictionaryID WHERE dt.FieldName = ''Priority''');
  CALL proc_statement(v_Query);

  SET v_Query = CONCAT('SELECT dtt.* FROM ',v_DicDataTable, 
                    ' dtt JOIN ', v_DicTable, ' dt ON dt.ID = dtt.DictionaryID WHERE dt.FieldName = ''State''');
  CALL proc_statement(v_Query);

END;

create
    definer = b7f925ce22548b@`%` procedure proc_statement(IN dynamic_statement mediumtext)
BEGIN
  SET @dynamic_statement := dynamic_statement;
  PREPARE prepare_statment FROM @dynamic_statement;
  EXECUTE prepare_statment;

  DEALLOCATE PREPARE prepare_statment;
END;


