-- Select * from Pokedex;
-- select * from Pokemon;
-- select * from USERs;

-- insert into pokemon values (4, 'Charmander', 5, 1, 0, 'fire')
-- insert into pokemon values (7, 'Squirtle', 5, 1, 0, 'water')
-- insert into pokemon values (1, 'Bulbasaur', 5, 1, 0, 'grass')
-- insert into pokemon values (25, 'Pikachu', 5, 1, 0, 'electric')
-- insert into pokemon values (133, 'Eevee', 5, 1, 0, 'normal')

-- insert into pokemon values (92, 'Gastly', 5, 1, 0, 'ghost')
-- insert into pokemon values (54, 'Psyduck', 5, 1, 0, 'water')
-- insert into pokemon values (303, 'Mawile', 5, 1, 0, 'steel')
-- insert into pokemon values (120, 'Staryu', 5, 1, 0, 'water')
-- insert into pokemon values (63, 'Abra', 5, 1, 0, 'psychic')

-- insert into pokemon values (198, 'Murkrow', 5, 1, 0, 'dark')
-- insert into pokemon values (16, 'Pidgey', 5, 1, 0, 'flying')
-- insert into pokemon values (50, 'Diglet', 5, 1, 0, 'ground')
-- insert into pokemon values (95, 'Onix', 5, 1, 0, 'rock')
-- insert into pokemon values (23, 'Ekans', 5, 1, 0, 'poison')

-- insert into pokemon values (21, 'Spearow', 5, 1, 0, 'flying')
-- insert into pokemon values (69, 'Bellsprout', 5, 1, 0, 'grass')
-- insert into pokemon values (147, 'Dratini', 5, 1, 0, 'dragon')
-- insert into pokemon values (77, 'Ponyta', 5, 1, 0, 'fire')
-- insert into pokemon values (127, 'Pinsir', 5, 1, 0, 'bug')

-- insert into pokemon values (607, 'Litwick', 5, 1, 0, 'ghost')
-- insert into pokemon values (667, 'LitLeo', 5, 1, 0, 'fire')
-- insert into pokemon values (289, 'Slakoth', 5, 1, 0, 'normal')
-- insert into pokemon values (74, 'Geodude', 5, 1, 0, 'rock')
-- insert into pokemon values (302, 'Sableye', 5, 1, 0, 'dark')

-- insert into pokemon values (39, 'Jigglypuff', 5, 1, 0, 'fairy')
-- insert into pokemon values (132, 'Ditto', 5, 1, 0, 'normal')
-- insert into pokemon values (359, 'Absol', 5, 1, 0, 'dark')
-- insert into pokemon values (175, 'Togepi', 5, 1, 0, 'fairy')
-- insert into pokemon values (235, 'Smeargle', 5, 1, 0, 'normal')


select * from pokemon order by type1;

select * from users
select * from Matches
Select * from Users Where matches > 0 Order By (wins *1.0) /(matches * 1.0) desc

-- insert into Users(username, password, matches, wins, losses) VALUES ('bot', 'p@ssw0rd', 0 ,0,0)
-- insert into Users(username, password, matches, wins, losses) VALUES ('guest', 'p@ssw0rd', 0 ,0,0)
