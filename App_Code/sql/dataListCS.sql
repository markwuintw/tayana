WITH newsss AS
(
/*--order by 請在程式覆蓋 ORDER BY ModulePublish.initDate --*/


SELECT     ROW_NUMBER() OVER(ORDER BY news.initdate desc) AS RowNumber,*
                    

FROM		news

WHERE	1=1



/*--where begin --*/

/*--where End--*/
)
select * from newsss where ROWNUMBER >=((@page - 1) * 5 + 1)  and ROWNUMBER <=(@page * 5)


