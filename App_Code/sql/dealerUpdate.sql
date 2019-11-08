SELECT    *,(select country from dealers where dealers.id=fid) as country

FROM		dealercity

WHERE	1=1 
