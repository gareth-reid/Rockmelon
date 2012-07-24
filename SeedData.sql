Print 'Seeding Games....'
delete from rating
delete from game
insert into dbo.Game select 'World of Warcraft', 'Sed vulputate magna ligula, vitae consequat est. Etiam nec eros mauris. Donec tristique, tellus in ultricies viverra, purus ligula consectetur metus, ut interdum purus erat tristique risus. Etiam ac tincidunt mauris.'
declare @id int 
set @id = scope_identity()
insert into dbo.Rating select @id, 5
insert into dbo.Rating select @id, 1
insert into dbo.Game select 'Minute to Win IT', 'Nunc vitae mi egestas tortor aliquet dapibus id eget dui. Ut vitae dapibus nibh. Curabitur ultrices, nunc vitae gravida iaculis, ante lectus pharetra magna, ac imperdiet ipsum neque a purus. '
set @id = scope_identity()
insert into dbo.Rating select @id, 2
insert into dbo.Rating select @id, 2
insert into dbo.Game select 'Rush', 'Aliquam vehicula nunc in nibh porta condimentum. Morbi et nulla at mi tempor placerat ut nec ipsum.'
set @id = scope_identity()
insert into dbo.Rating select @id, 2
insert into dbo.Rating select @id, 2
insert into dbo.Game select 'Toy Soldiers', 'Nullam eget nisi purus, ut posuere lacus. Maecenas commodo risus sed justo placerat commodo vel sit amet dolor. Phasellus iaculis, lectus sed luctus interdum, nisi est fringilla augue, eu interdum purus enim vel mi.'
set @id = scope_identity()
insert into dbo.Rating select @id, 1
insert into dbo.Rating select @id, 4
insert into dbo.Game select 'Plants vs Zombies', 'Maecenas non massa ut ante vehicula mattis a nec turpis. Etiam quis lorem ipsum, vel dapibus eros. Ut hendrerit, mauris eleifend tempor bibendum, lorem nunc hendrerit enim, ut imperdiet sapien felis id ipsum.'
set @id = scope_identity()
insert into dbo.Rating select @id, 1
insert into dbo.Rating select @id, 1
