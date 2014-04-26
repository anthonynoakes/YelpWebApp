select h.business_id from hours h
	where h.business_id = 'MiVcQsXp3TYUmeD7FSa-hA'
	and h.day_number = DATEPART(dw, GETDATE())
	and DATEPART(hh,h.[open]) <= DATEPART(hh, GETDATE())
	and DATEPART(hh,h.[close]) >= DATEPART(hh, GETDATE());

select h.day_number, DATEPART(hh, h.[open]) as [open], DATEPART(hh, h.[close]) as [close] from  hours h
	where h.business_id = 'WNRpiUVARmEIjHRiqJstBQ'
	order by day_number asc;

	select * from hours

	select DATEPART(hh, GETDATE());

	select DATEPART(dw, GETDATE());

	select GETDATE()

	//update dw of week sunday = 1

	update hours
	set day_number = 1
	where day_name = 'Sunday'

	select * from business	
		where business_id = 'ZZy5EwrI3wyHw8y54jZruA'

	select * from reviews	
		where review_id like '%-RDZxLTUExM9Q02x4hZmHg%'

select count(*) from reviews;

select sum(review_count) from business
	group by review_count;

select count(distinct(name)) from categories