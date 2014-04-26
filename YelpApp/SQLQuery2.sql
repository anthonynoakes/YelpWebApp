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


select r.business_id, sum(r.stars)/count(*) as stars from reviews r
	where month(r.date) = 6
	and year(r.date) = 2011
	group by r.business_id

SELECT * from (
	select r.business_id, sum(r.stars)/count(*) as stars from reviews r
	where month(r.date) = 6
	and year(r.date) = 2011
	group by r.business_id
	) x
	join categories c
	on x.business_id = c.business_id
	WHERE name IN (
		select c.name, max(x.stars) from reviews
		join categories
		on reviews.business_id = categories.business_id
		group by categories.name
	);

select * from users
	