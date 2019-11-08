WITH dealercityyy AS
(
/*--order by 請在程式覆蓋 ORDER BY ModulePublish.initDate --*/


SELECT     ROW_NUMBER() OVER(ORDER BY dealercity.initdate asc) AS RowNumber,*,(select country from dealers where dealers.id=fid) as country

FROM		dealercity

WHERE	1=1 



/*--where begin --*/

/*--where End--*/
)
select * from  dealercityyy 