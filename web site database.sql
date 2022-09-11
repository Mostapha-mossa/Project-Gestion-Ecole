create database ecoleprojecte


--CREATE TABLE Niveau(Code_niveau varchar(50) primary key,intitu�_niveau varchar(50), date_Cr�ation date) --les valeurs possibles: Technicien, Technicien  sp�cialis�,Qualification, Sp�cialisation
--CREATE TABLE Secteur(code_sect varchar(50) primary key, intitul�_sect varchar(50), date_Cr�ation date) -- les valeurs possibles: NTIC, Batiment, Service ,Industriel, ...
--CREATE TABLE Fili�re(code_Fil varchar(50) primary key, nom_Fil varchar(50),CoeNiveau varchar(50) FOREIGN KEY  REFERENCES Niveau(Code_niveau) , date_Cr�ation date, code_secteur varchar(50)FOREIGN KEY REFERENCES Secteur(code_sect))
--CREATE TABLE Groupe(Code_groupe varchar(50) primary key, Nom_Groupe varchar(50) ,Ann�e_scolaire varchar(50), Ann�e varchar(50), CodeFil varchar(50) FOREIGN KEY REFERENCES Fili�re(code_Fil))
--Ann�e scolaire exemple : 2018 � 2020
--Ann�e : 1i�re ann�e ou 2i�me ann�e
--CREATE TABLE Stagiaire(code_stagiaire varchar(50) primary key, nom_st varchar(50), prenom_st varchar(50), adress_st varchar(50), Photo varchar(50), email_st varchar(50), genre varchar(50),  tel_st varchar(50), DateNaiss date, diplome varchar(50), codegrp varchar(50)  FOREIGN KEY REFERENCES Groupe(Code_groupe))
--CREATE TABLE Inscription(code_stagiaire varchar(50) FOREIGN KEY REFERENCES Stagiaire(code_stagiaire),Code_groupe varchar(50) FOREIGN KEY REFERENCES Groupe(Code_groupe), dateInscription date,primary key (code_stagiaire,Code_groupe))
--CREATE TABLE Affecation (code_Ens varchar(50)FOREIGN KEY REFERENCES Enseignant(code_Ens), code_mod varchar(50)FOREIGN KEY REFERENCES Module(code_mod), code_fil varchar(50) FOREIGN KEY REFERENCES Fili�re(code_Fil),date_affectation date,primary key (code_Ens,code_mod,code_fil))

--CREATE TABLE Module(code_mod varchar(50) primary key, Intitul�_mod varchar(50))
--CREATE TABLE ModuleFiliere (code_mod varchar(50)FOREIGN KEY REFERENCES Module(code_mod), code_fil varchar(50) FOREIGN KEY REFERENCES Fili�re(code_Fil), masseHoraire varchar(50), Coefficient varchar(50),primary key (code_mod,code_fil))
--CREATE TABLE Examen(code_stagiaire varchar(50) FOREIGN KEY REFERENCES Stagiaire(code_stagiaire), code_mod varchar(50)FOREIGN KEY REFERENCES Module(code_mod), DateExamen date, Note money,primary key (code_stagiaire,code_mod))
--DROP TABLE Examen
--CREATE TABLE Enseignant ( code_Ens varchar(50) primary key, nom varchar(50), prenom varchar(50),cin varchar(50), dateNaissance date, adresse varchar(50), tel varchar(50),email varchar(50), Dipl�me varchar(50), grade  varchar(50), statut varchar(50))-- le statut put �tre : permanent, vacataire , encadrant
--CREATE TABLE Dipl�me (codeDip varchar(50) primary key, Intitul�_du_Dip varchar(50), sp�cialit� varchar(50), secteur varchar(50)FOREIGN KEY REFERENCES Secteur(code_sect))
--CREATE TABLE Absence  (code_Stagiaire varchar(50)FOREIGN KEY REFERENCES Stagiaire(code_stagiaire), code_mod varchar(50)FOREIGN KEY REFERENCES Module(code_mod), code_Absence varchar(50),Heure_abs varchar(50),Nbr_heure int, date_affectation date,primary key (code_Stagiaire,code_mod,code_Absence))
--CREATE TABLE compte( code_User varchar(50) primary key, Login varchar(50), mot_de_passe varchar(50), Type_User varchar(50))

insert into Enseignant values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','','" + textBox5.Text + "','" + textBox6.Text + "','" + maskedTextBox1.Text + "','" +  + "','" + textBox7.Text + "','" + comboBox1.Text + "')

update Niveau set intitu�_niveau='" + comboBox1.Text + "',date_Cr�ation='" +  + "' where Code_niveau='" + textBox1.Text + "'
insert into Stagiaire values ('" +  + "','"++"','" +  + "','" +  + "','" + + "','" +  + "','"++"','"++"','"++"','"++"','"++"')

insert into Stagiaire values ('" + textBox1.Text + "','" + textBox2.Text + "','" + maskedTextBox1.Text + "','" + comboBox1.Text + "','" + comboBox2.SelectedValue + "')
update Groupe set Nom_Groupe='" + textBox2.Text + "',Ann�e_scolaire='" + maskedTextBox1.Text + "',Ann�e='" + comboBox1.Text + "',CodeFil='" +  comboBox2.SelectedValue + "' where Code_groupe='" + textBox1.Text + "'



ALTER PROCEDURE P1 @CodeC varchar(50)
AS
begin

select distinct  Stagiaire.nom_st,Stagiaire.prenom_st ,Stagiaire.diplome,Groupe.Nom_Groupe,Groupe.Ann�e,Groupe.Ann�e_scolaire,Examen.DateExamen,Examen.Note,Module.Intitul�_mod from Examen,Stagiaire,Module,Groupe where Examen.code_stagiaire=Stagiaire.code_stagiaire AND Examen.code_mod=Module.code_mod AND Stagiaire.codegrp=Groupe.Code_groupe AND  Stagiaire.code_stagiaire=@CodeC
end






