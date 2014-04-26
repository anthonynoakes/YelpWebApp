select * from business b
	join categories c
	on c.business_id = b.business_id
	where exists (
		select business_id from business
			where b.business_id = '__CQhr0M-OpKdu0DXgGcaQ'
	);

select c.name, max([June 2011].stars) from (
		select r.business_id, sum(r.stars)/count(*) as stars from reviews r
		where month(r.date) = 6
		and year(r.date) = 2011
		group by r.business_id
	) [June 2011]
	inner join categories c
	on [June 2011].business_id = c.business_id
	where c.name like '%%'
	group by c.name
	order by max([June 2011].stars) desc;

select avg(business.stars) from business

select sum(r.stars) from users u
	join reviews r
	on u.user_id = r.user_id
	join business b
	on b.business_id = b.business_id
	group by r.business_id

select * from business b
	join reviews r 
	on b.business_id = r.business_id;

select * from (
	select business_id, stars, stars * review_count as total from business		
	) s1
	join (
	select business_id from reviews
		join users
		on reviews.user_id = users.user_id
		group by business_id
	) s2
	on s1.business_id = s2.business_id

select * from reviews r1
	join users u1
	on r1.user_id = u1.user_id

select s1.business_id, s1.stars, s1.total, s2.avg_total from (
	select business_id, stars, stars * review_count as total from business		
	) s1
	join (
	select business_id, sum(users.average_stars) as avg_total from reviews
	join users
	on reviews.user_id = users.user_id
	group by reviews.business_id
	order by avg_total desc
	) s2
	on s1.business_id = s2.business_id;

select b.business_id, b.stars, s2.avg_total/s2.counts as norm from business b
	join (
	select business_id, count(users.average_stars) as counts, sum(users.average_stars) as avg_total from reviews
	join users
	on reviews.user_id = users.user_id
	group by reviews.business_id
	) s2
	on b.business_id = s2.business_id
	order by abs(s2.avg_total/s2.counts - b.stars) desc

select b.business_id, b.stars, s2.avg_total/s2.counts as norm from business b
	join (
	select business_id, count(users.average_stars) as counts, sum(users.average_stars) as avg_total from reviews
	join users
	on reviews.user_id = users.user_id
	group by reviews.business_id
	) s2
	on b.business_id = s2.business_id

select * from users
	join reviews
	on users.user_id = reviews.user_id
	where business_id ='kLfJNtvpbomNTD8tqm7ukQ';

select avg(stars) from reviews